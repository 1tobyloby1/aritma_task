import LoanTypes from "./components/LoanTypes.tsx";
import Box from '@mui/material/Box';
import { useState } from "react";
import LoanCalculator from "./components/LoanCalculator.tsx";
import LoanType from "./models/LoanType.ts";
import Typography from '@mui/material/Typography';

function App() {
    const [loanType, setLoanType] = useState<LoanType>();
    
    return (
        <Box sx={{ display: "flex", alignItems: "center", flexDirection: "column" }}>
            <Typography variant="h4">Lånekalkulator</Typography>
            <LoanTypes selected={loanType} onChange={(type) => setLoanType(type)} />
            {loanType && <LoanCalculator loanType={loanType} />}
        </Box>
    );
}

export default App;