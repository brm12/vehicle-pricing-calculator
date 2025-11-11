import { computed, reactive, watch } from 'vue'
import axios, { AxiosError } from 'axios'
import { useToast } from 'primevue/usetoast'
import type { FeesResponse, Fee } from '@/types/feeTypes'

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL

interface VehicleType {
  id: number
  name: string
}

export const useVehiclePricingForm = () => {
  const state = reactive({
    vehiclePrice: null as number | null,
    selectedType: null as number | null,
    vehicleTypeOptions: [] as VehicleType[],
    feeBreakdown: [] as Fee[],
    totalAmount: 0,
    isCalculating: false,
    hasCalculation: false
  })

  const toast = useToast()

  const initializeVehicleTypes = async () => {
    try {
      const response = await axios.get<VehicleType[]>(`${API_BASE_URL}/VehiclePricing/vehicleTypes`)
      state.vehicleTypeOptions = response.data.map((type: VehicleType) => ({
        id: type.id,
        name: type.name
      }))
    } catch (error) {
      showError('Failed to load vehicle types. Please refresh the page.')
      console.error('Error fetching vehicle types:', error)
    }
  }

  const calculateBid = async () => {
    if (!validateInput()) return

    state.isCalculating = true
    state.hasCalculation = false

    try {
      const response = await axios.post<FeesResponse>(`${API_BASE_URL}/VehiclePricing/calculate`, {
        basePrice: state.vehiclePrice,
        vehicleTypeId: state.selectedType
      })

      processCalculationResult(response.data)
      showSuccess('Calculation completed successfully!')
    } catch (error) {
      handleCalculationError(error)
    } finally {
      state.isCalculating = false
    }
  }

  const validateInput = (): boolean => {
    if (!state.vehiclePrice || state.vehiclePrice <= 0) {
      showError('Please enter a valid vehicle price.')
      return false
    }

    if (!state.selectedType) {
      showError('Please select a vehicle type.')
      return false
    }

    if (state.vehiclePrice > 10000000) {
      showError('Vehicle price seems unusually high. Please verify the amount.')
      return false
    }

    return true
  }

  const processCalculationResult = (data: FeesResponse) => {
    state.feeBreakdown = data.feeBreakdown
    state.totalAmount = data.totalPrice
    state.hasCalculation = true
  }

  const handleCalculationError = (error: unknown) => {
    console.error('Calculation error:', error)
    
    if (error instanceof AxiosError) {
      if (error.response?.data?.errors) {
        const errorMessages = Object.values(error.response.data.errors).flat() as string[]
        errorMessages.forEach(message => showError(message))
      } else if (error.response?.status === 400) {
        showError('Invalid input data. Please check your values and try again.')
      } else if (error.response?.status && error.response.status >= 500) {
        showError('Server error. Please try again later.')
      } else {
        showError('Calculation failed. Please try again.')
      }
    } else {
      showError('Network error. Please check your connection and try again.')
    }
  }

  const clearCalculation = () => {
    state.feeBreakdown = []
    state.totalAmount = 0
    state.hasCalculation = false
    state.vehiclePrice = null
    state.selectedType = null
  }

  const formatCurrency = (amount: number): string => {
    return new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency: 'USD',
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    }).format(amount)
  }

  const showSuccess = (message: string) => {
    toast.add({
      severity: 'success',
      summary: 'Success',
      detail: message,
      life: 3000
    })
  }

  const showError = (message: string) => {
    toast.add({
      severity: 'error',
      summary: 'Error',
      detail: message,
      life: 5000
    })
  }

  const vehiclePrice = computed({
    get: () => state.vehiclePrice,
    set: (value) => {
      state.vehiclePrice = value
      if (state.hasCalculation) {
        state.hasCalculation = false
        state.feeBreakdown = []
        state.totalAmount = 0
      }
    }
  })

  const selectedType = computed({
    get: () => state.selectedType,
    set: (value) => {
      state.selectedType = value
      if (state.hasCalculation) {
        state.hasCalculation = false
        state.feeBreakdown = []
        state.totalAmount = 0
      }
    }
  })

  watch([() => state.vehiclePrice, () => state.selectedType], () => {
    if (state.vehiclePrice && state.selectedType) {
      calculateBid()
    }
  })

  initializeVehicleTypes()

  return {
    vehiclePrice,
    selectedType,
    vehicleTypeOptions: computed(() => state.vehicleTypeOptions),
    feeBreakdown: computed(() => state.feeBreakdown),
    totalAmount: computed(() => state.totalAmount),
    isCalculating: computed(() => state.isCalculating),
    hasCalculation: computed(() => state.hasCalculation),

    calculateBid,
    clearCalculation,
    formatCurrency,

    initializeVehicleTypes
  }
}