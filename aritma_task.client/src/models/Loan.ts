import LoanType from "./LoanType.ts";
import {AmortizationDetail} from "./AmortizationDetail.ts";

export default interface Loan {
    id: number;
    loanType: LoanType;
    amount: number;
    termInYears: number;
    amortizationSchedule: AmortizationDetail[];
}