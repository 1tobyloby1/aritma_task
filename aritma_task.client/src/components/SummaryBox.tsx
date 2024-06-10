import Loan from "../models/Loan.ts";
import Box from '@mui/material/Box';
import { styled } from '@mui/material/styles';

const StyledBox = styled(Box)(({ theme }) => ({
    padding: theme.spacing(3),
    background: "lightgrey",
    width: "100%",
    maxWidth: 800,
    margin: `${theme.spacing(7)} 0`
}));

const SummaryBox = ({ loan }:{ loan: Loan }) => {
    const totaltPayments = loan.amortizationSchedule.length;
    const totalInterest = loan.amortizationSchedule.reduce((acc, item) => acc + item.interestPayment, 0)
        .toFixed(2);
    
    return <StyledBox>
        <Box display="flex" justifyContent="space-around">
            <Box>Antall betalinger: {totaltPayments}</Box>
            <Box>Totalt renter og gebyrer: {totalInterest} kr</Box>
        </Box>
    </StyledBox>
}

export default SummaryBox;