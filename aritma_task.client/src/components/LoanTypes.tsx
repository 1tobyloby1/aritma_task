import Card from "./Card.tsx";
import { useMemo, useEffect, useState } from "react";
import Box from '@mui/material/Box';
import Api from "../functions/Api.ts";
import LoanType from "../models/LoanType.ts";

const LoanTypes = (props: {onChange: (type: LoanType) => void, selected: LoanType | undefined}) => {
    const [loanTypes, setLoanTypes] = useState<LoanType[]>([]);
    const [isLoading, setIsLoading] = useState(true);

    const fetchTypes = async() => {
        const data: LoanType[] = await Api<LoanType[]>('GET', '/loans/types');
        setLoanTypes(data);
        setIsLoading(false);
        props.onChange(data[0]);
    }
    
    const typesElm = useMemo(() => {
        return loanTypes.map((type) => {
            return <Box key={type.id} onClick={() => props.onChange(type)} sx={{ display: "inline" }}>
                <Card active={props.selected!.id === type.id}>{type.name}</Card>
            </Box>
        })
    }, [props.selected]);

    useEffect(() => {
        fetchTypes();
    }, []);
    
    if (isLoading) return <Box>Loading...</Box>
    return <Box>{typesElm}</Box>
}

export default LoanTypes