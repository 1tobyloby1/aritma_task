import { render, screen } from '@testing-library/react';
import LoanCalculator from '../../components/LoanCalculator';
import LoanType from "../../models/LoanType.ts";

test('calculates loan', () => {
    const mockLoanType: LoanType = {
        id: 1,
        name: 'Boliglån',
        interestRate: 5.0,
        loanAmountMax: 500000,
        loanAmountMin: 50000,
        termInYearsMax: 30,
        termInYearsMin: 5
    };
    
    render(<LoanCalculator loanType={mockLoanType} />);

    const loanElm = screen.getByText("Ønsker lånesum:");
    expect(loanElm).toBeInTheDocument();

    const durationElm = screen.getByText("Nedbetalingstid:");
    expect(durationElm).toBeInTheDocument();
});
