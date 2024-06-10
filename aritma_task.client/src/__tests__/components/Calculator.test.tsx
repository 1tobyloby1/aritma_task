import { render, screen } from '@testing-library/react';
import Calculator from '../../components/Calculator';

test('renders Calculator component', () => {
    render(<Calculator />);
    const linkElement = screen.getByText(/calculate/i);
    expect(linkElement).toBeInTheDocument();
});