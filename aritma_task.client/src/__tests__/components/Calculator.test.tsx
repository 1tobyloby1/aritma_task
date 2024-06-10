import { render, screen, fireEvent } from '@testing-library/react';
import Calculator from '../../components/Calculator';
import LoanRequest from "../../models/LoanRequest.ts";

test('renders Calculator component', () => {
    const mockLoanRequest: LoanRequest = {
        loanTypeId: 1,
        amount: 500000,
        termInYears: 2
    };
    
    render(<Calculator loanRequest={mockLoanRequest} />);

    const calculateButton = screen.getByText("Regn ut");
    fireEvent.click(calculateButton);
});