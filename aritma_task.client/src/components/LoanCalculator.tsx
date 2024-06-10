import InputSlider from "./InputSlider.tsx";
import { useState, useMemo } from "react";
import Calculator from "./Calculator.tsx";
import LoanType from "../models/LoanType.ts";

const LoanCalculator = ({ loanType }:{ loanType: LoanType }) => {
    const loanAmount = useState(0);
    const downPaymentDuration = useState(0);
    
    const loanElm = useMemo(() => {
        return <InputSlider input={loanAmount} min={loanType.loanAmountMin} max={loanType.loanAmountMax} label="Ønsker lånesum:" unit="kr" />;
    }, [loanAmount[0], loanType]);
    
    const durationElm = useMemo(() => {
        return <InputSlider input={downPaymentDuration} min={loanType.termInYearsMin} max={loanType.termInYearsMax} label="Nedbetalingstid:" unit="år" />;
    }, [downPaymentDuration[0], loanType]);
    
    return <>
        {loanElm}
        {durationElm}
        <Calculator loanRequest={{ loanTypeId: loanType.id, amount: loanAmount[0], termInYears: downPaymentDuration[0] }} />
    </>;
}

export default LoanCalculator;