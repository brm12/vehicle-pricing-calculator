import { describe, it, expect } from 'vitest'

describe('Basic Math Functions', () => {
  it('should add two numbers correctly', () => {
    const add = (a: number, b: number) => a + b
    
    expect(add(5, 3)).toBe(8)
    expect(add(0, 0)).toBe(0)
    expect(add(-5, 5)).toBe(0)
  })

  it('should calculate percentage correctly', () => {
    const calculatePercentage = (value: number, percentage: number) => {
      return (value * percentage) / 100
    }
    
    expect(calculatePercentage(100, 10)).toBe(10)
    expect(calculatePercentage(1000, 2.5)).toBe(25)
    expect(calculatePercentage(50, 0)).toBe(0)
  })
})

describe('String Functions', () => {
  it('should format currency without dependencies', () => {
    const formatMoney = (amount: number) => {
      return new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD'
      }).format(amount)
    }
    
    expect(formatMoney(1000)).toBe('$1,000.00')
    expect(formatMoney(99.99)).toBe('$99.99')
  })
})