import LoanRequest from "../models/LoanRequest.ts";
import Api from "../functions/Api.ts";
import Loan from "../models/Loan.ts";
import { useState, useMemo } from "react";
import Button from '@mui/material/Button';
import AmortizationSchedule from "./AmortizationSchedule.tsx";
import SummaryBox from "./SummaryBox.tsx";
import Box from '@mui/material/Box';
import Typography from "@mui/material/Typography";

const Calculator = ({ loanRequest }:{ loanRequest: LoanRequest }) => {
    const [loan, setLoan] = useState<Loan>();
    const [isLoading, setIsLoading] = useState(false);

    const calculate = async() => {
        setIsLoading(true);
        const data = await Api<Loan>("POST","/loans", loanRequest);
        setLoan(data);
        setIsLoading(false)
    }

    const summaryLoan = useMemo(() => {
        if (isLoading) return <Box>loading...</Box>;
        
        return loan && <>
            <SummaryBox loan={loan} />
            <Typography variant="h5">Nedbetalingsplan</Typography>
            <AmortizationSchedule amortizationSchedule={loan.amortizationSchedule} /></>
    }, [loan, isLoading]);
    
    return <>
        <Button variant="contained" onClick={calculate} sx={{ mt: 4, px: 5, py: 1 }}>Regn ut</Button>
        {summaryLoan}
    </>
}

export default Calculator;