import { ReactNode } from "react";
import Paper from '@mui/material/Paper';
import { styled } from '@mui/material/styles';

const Card = (props: { children: ReactNode, active?: boolean }) => {
    const StyledPaper = styled(Paper)(({ theme }) => ({
        margin: 15,
        width: 150,
        padding: theme.spacing(2),
        display: "inline-block",
        border: "3px solid grey",
        borderColor: props.active ? theme.palette.primary.main : "",
        cursor: "pointer"
    }));
    
    return <StyledPaper elevation={2}>{props.children}</StyledPaper>
}

export default Card;