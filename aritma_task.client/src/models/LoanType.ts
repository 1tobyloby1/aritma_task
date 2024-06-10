export default interface LoanType {
    id: number;
    name: string;
    interestRate: number;
    loanAmountMax: number;
    loanAmountMin: number;
    termInYearsMax: number;
    termInYearsMin: number;
}