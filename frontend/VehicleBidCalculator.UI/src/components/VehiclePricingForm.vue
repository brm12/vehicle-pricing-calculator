<script setup lang="ts">
import { useVehiclePricingForm } from '@/composables/useVehiclePricingForm'
import InputNumber from 'primevue/inputnumber'
import IconField from 'primevue/iconfield'
import InputIcon from 'primevue/inputicon'
import Dropdown from 'primevue/dropdown'
import Button from 'primevue/button'
import Toast from 'primevue/toast'

const {
  vehiclePrice,
  selectedType,
  vehicleTypeOptions,
  feeBreakdown,
  totalAmount,
  hasCalculation,
  clearCalculation,
  formatCurrency
} = useVehiclePricingForm()
</script>

<template>
  <Toast />
  <form class="vehicle-form">
    <div class="form-group">
      <label for="base-price">Vehicle Base Price:</label>
      <IconField>
        <InputIcon class="pi pi-dollar" />
        <InputNumber 
          id="base-price"
          v-model="vehiclePrice" 
          placeholder="0.00"
          :minFractionDigits="2"
          :maxFractionDigits="2"
        />
      </IconField>
    </div>
    <div class="form-group">
      <label for="vehicle-type">Vehicle Type:</label>
      <Dropdown 
        id="vehicle-type" 
        v-model="selectedType" 
        :options="vehicleTypeOptions" 
        optionLabel="name" 
        optionValue="id" 
        placeholder="Select a Vehicle Type" 
      />
    </div>
    <div v-if="hasCalculation" class="form-group">
      <Button 
        @click="clearCalculation" 
        severity="secondary" 
        outlined 
        class="clear-btn"
      >
        Clear
      </Button>
    </div>
    <div v-if="hasCalculation" class="fees-section">
      <h3>Fees:</h3>
      <ul>
        <li v-for="fee in feeBreakdown" :key="fee.id">
          {{ fee.feeTypeName }}: {{ formatCurrency(fee.calculatedFee) }}
        </li>
      </ul>
    </div>
    <div v-if="hasCalculation" class="total-cost">
      <h3>Total Cost: {{ formatCurrency(totalAmount) }}</h3>
    </div>
  </form>
</template>

<style scoped>
.vehicle-form {
  width: 550px;
  margin: 2rem auto;
  padding: 1.5rem;
  border: 1px solid #ddd;
  border-radius: 12px;
  background-color: rgba(255, 255, 255, 0.95);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(10px);
}

.form-group {
  margin-bottom: 1.5rem;
}

label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: bold;
  color: #333;
  font-size: 1rem;
}

.calculate-btn {
  width: 100%;
  margin-bottom: 0.75rem;
  font-weight: 600 !important;
  padding: 0.875rem !important;
}

.clear-btn {
  width: 100%;
  font-weight: 500 !important;
  padding: 0.75rem !important;
}

.fees-section {
  margin-top: 1.5rem;
}

.fees-section h3 {
  margin-bottom: 0.75rem;
  color: #333;
  font-size: 1.2rem;
}

.fees-section ul {
  list-style-type: none;
  padding: 0;
}

.fees-section li {
  background-color: #fff;
  padding: 0.75rem;
  border: 1px solid #e0e0e0;
  border-radius: 8px;
  margin-bottom: 0.5rem;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.05);
  font-weight: 500;
}

.total-cost {
  margin-top: 1.5rem;
  font-size: 1.3rem;
  font-weight: bold;
  text-align: center;
  color: #2c3e50;
  padding: 1rem;
  background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
  border-radius: 8px;
  border: 2px solid #e0e0e0;
}

/* PrimeVue component styling */
:deep(.p-inputtext) {
  width: 100% !important;
  padding: 0.75rem !important;
  font-size: 1rem !important;
  border-radius: 8px !important;
  border: 2px solid #e0e0e0 !important;
}

:deep(.p-inputtext:focus) {
  border-color: #667eea !important;
  box-shadow: 0 0 0 2px rgba(102, 126, 234, 0.2) !important;
}

:deep(.p-dropdown) {
  width: 100% !important;
}

:deep(.p-dropdown .p-dropdown-trigger) {
  border-radius: 0 8px 8px 0 !important;
}

:deep(.p-dropdown .p-dropdown-label) {
  padding: 0.75rem !important;
  font-size: 1rem !important;
  border-radius: 8px 0 0 8px !important;
  border: 2px solid #e0e0e0 !important;
}

:deep(.p-dropdown:not(.p-disabled):hover .p-dropdown-label) {
  border-color: #667eea !important;
}

:deep(.p-dropdown.p-focus .p-dropdown-label) {
  border-color: #667eea !important;
  box-shadow: 0 0 0 2px rgba(102, 126, 234, 0.2) !important;
}

:deep(.p-iconfield) {
  width: 100% !important;
}

:deep(.p-iconfield .p-inputtext) {
  padding-left: 2.5rem !important;
}

@media (max-width: 768px) {
  .vehicle-form {
    width: 95%;
    margin: 1rem auto;
    padding: 1rem;
  }
}
</style>