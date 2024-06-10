export interface AmortizationDetail {
    month: Date;
    monthlyPayment: number;
    interestPayment: number;
    principalPayment: number;
    remainingBalance: number;
}