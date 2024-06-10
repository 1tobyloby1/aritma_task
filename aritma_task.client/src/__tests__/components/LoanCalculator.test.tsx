import { render, screen, fireEvent } from '@testing-library/react';
import LoanCalculator from '../../components/LoanCalculator';

test('calculates loan', () => {
    render(<LoanCalculator />);
    const calculateButton = screen.getByText(/calculate/i);
    fireEvent.click(calculateButton);
    const result = screen.getByText(/monthly payment/i);
    expect(result).toBeInTheDocument();
});
