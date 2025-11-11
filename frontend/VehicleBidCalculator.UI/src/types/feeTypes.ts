export interface FeeType {
  id: number
  name: string
}

export interface Fee {
  id: number
  feeTypeId: number
  feeTypeName: string
  calculatedFee: number
}

export interface FeesResponse {
  totalPrice: number
  feeBreakdown: Fee[]
}
