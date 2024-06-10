import {AmortizationDetail} from "../models/AmortizationDetail.ts";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import { styled } from '@mui/material/styles';
import FormatDate from "../functions/FormatDate.ts";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
        backgroundColor: theme.palette.common.black,
        color: theme.palette.common.white,
        fontWeight: "bold"
    },
}));

const AmortizationSchedule = ({ amortizationSchedule }:{ amortizationSchedule: AmortizationDetail[] }) => {
    return <Table sx={{ maxWidth: 800 }} aria-label="Downpayment plan">
            <TableHead>
                <TableRow>
                    <StyledTableCell>Dato</StyledTableCell>
                    <StyledTableCell>Å betale</StyledTableCell>
                    <StyledTableCell>Renter og gebyrer</StyledTableCell>
                    <StyledTableCell>Avdrag</StyledTableCell>
                    <StyledTableCell>Restgjeld</StyledTableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {amortizationSchedule.map((row) => (
                    <TableRow
                        key={row.month.toString()}
                        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                    >
                        <TableCell>{FormatDate(row.month)}</TableCell>
                        <TableCell>{row.monthlyPayment} kr</TableCell>
                        <TableCell>{row.interestPayment} kr</TableCell>
                        <TableCell>{row.principalPayment} kr</TableCell>
                        <TableCell>{row.remainingBalance} kr</TableCell>
                    </TableRow>
                ))}
            </TableBody>
        </Table>
}

export default AmortizationSchedule;