import Box from '@mui/material/Box';
import Slider from '@mui/material/Slider';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputAdornment from '@mui/material/InputAdornment';
import Typography from '@mui/material/Typography';
import { Dispatch, useEffect } from "react";

const InputSlider = (props: { max: number, min: number, unit: string, label: string, input: [number, Dispatch<number>] }) => {
    const handleSliderChange = (_: Event, newValue: number | number[]) => {
        props.input[1](newValue as number);
    };

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        props.input[1](event.target.value === '' ? 0 : Number(event.target.value));
    };

    const handleBlur = () => {
        if (props.input[0] < props.min) props.input[1](props.min);
        else if (props.input[0] > props.max) props.input[1](props.max);
    };

    useEffect(() => {
        handleBlur();
    }, [props.max, props.min]);
    
    return <Box sx={{ textAlign: "left" }}>
        <Typography>{props.label}</Typography>
        <Box sx={{ display: "flex", alignItems: "center", gap: 3 }}>
            <Slider value={props.input[0]} onChange={handleSliderChange} sx={{ width: 200 }} {...props} />
            <OutlinedInput
                value={props.input[0]}
                size="small"
                onChange={handleInputChange}
                onBlur={handleBlur}
                inputProps={{
                    type: "number",
                    ...props
                }}
                endAdornment={<InputAdornment position="end">{props.unit}</InputAdornment>}
            />
        </Box>
    </Box>;
}

export default InputSlider;