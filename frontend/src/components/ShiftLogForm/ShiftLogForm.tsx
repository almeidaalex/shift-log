import DateFnsUtils from "@date-io/date-fns";
import {
    Button,
    FormControl,
    FormControlLabel,
    InputLabel,
    MenuItem,
    Select,
    Switch,
    TextField,
} from "@material-ui/core";
import {
    KeyboardDatePicker,
    MuiPickersUtilsProvider,
} from "@material-ui/pickers";
import { useState } from "react";
import { Controller, useForm } from "react-hook-form";
import Shift from "../../models/Shift";
import { DeleteDialog } from "../DeleteDialog";
import "./AddShiftLog.css";
import { yupResolver } from "@hookform/resolvers/yup";
import * as Yup from "yup";

type ShiftFormProps = {
    onSubmit: (shift: Shift) => void;
    onDeleteConfirm?: (id: number) => void;
    data?: Shift;
};

const validationSchema = Yup.object().shape({
    comment: Yup.string().required("Comment is required"),
    operator: Yup.string().required("Operator is required"),
    eventDate: Yup.date().required("Event Date is required"),
    area: Yup.number().required("Area is required"),
    status: Yup.boolean().required("Status is required"),
});

const ShiftLogForm = (props: ShiftFormProps) => {
    const { data, onSubmit, onDeleteConfirm } = props;
    const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);
    const {
        handleSubmit,
        control,
        formState: { errors },
    } = useForm<Shift>({
        defaultValues: data,
        resolver: yupResolver(validationSchema),
    });

    console.log(errors);

    return (
        <form
            className="AddShiftLog form"
            onSubmit={handleSubmit(onSubmit)}
            noValidate
        >
            <MuiPickersUtilsProvider utils={DateFnsUtils}>
                <Controller
                    render={({ field }) => (
                        <KeyboardDatePicker
                            disableToolbar
                            variant="inline"
                            margin="normal"
                            format="MM/dd/yyyy"
                            id="event-date-picker"
                            label="Event Date"
                            defaultValue=""
                            error={errors?.eventDate?.type === "required"}
                            helperText={errors?.eventDate?.message}
                            KeyboardButtonProps={{
                                "aria-label": "change date",
                            }}
                            {...field}
                        />
                    )}
                    name="eventDate"
                    control={control}
                />
            </MuiPickersUtilsProvider>

            <Controller
                name="area"
                control={control}                
                render={({ field }) => (
                    <FormControl>
                        <InputLabel id="area-label">Area</InputLabel>
                        <Select
                            {...field}
                            labelId="area-label"
                            error={errors?.area?.type === "required"} 
                            required
                        >                            
                            <MenuItem value={1}>Control Room</MenuItem>
                            <MenuItem value={2}>Factory Floor</MenuItem>
                            <MenuItem value={3}>Expedition</MenuItem>
                        </Select>
                    </FormControl>
                )}
            />

            <Controller
                control={control}
                name="machine"
                render={({ field }) => <TextField {...field} label="Machine" />}
            />

            <Controller
                control={control}
                name="operator"
                render={({ field }) => (
                    <TextField
                        {...field}
                        label="Operator"
                        required={true}
                        error={errors?.operator?.type === "required"}
                        helperText={errors?.operator?.message}
                    />
                )}
            />

            <Controller
                control={control}
                name="status"
                render={({ field: { value, onChange } }) => (
                    <FormControlLabel
                        control={<Switch checked={value} onChange={onChange} />}
                        label="Status"
                    />
                )}
            />

            <Controller
                control={control}
                name="comment"
                render={({ field }) => (
                    <TextField
                        {...field}
                        multiline
                        rows={5}
                        required={true}
                        label="Comment"
                        error={errors?.comment?.type === "required"}
                        helperText={errors?.comment?.message}
                    />
                )}
            />

            <Button color="primary" variant="outlined" type="submit">
                Save
            </Button>
            <Button
                color="primary"
                variant="outlined"
                type="submit"
                onClick={(e) => {
                    e.preventDefault();
                    setDeleteDialogOpen(true);
                }}
            >
                Delete
            </Button>

            <DeleteDialog
                open={deleteDialogOpen}
                onConfirm={() => {
                    setDeleteDialogOpen(false);
                    onDeleteConfirm && onDeleteConfirm(data?.id || 0);
                }}
                onCancel={() => setDeleteDialogOpen(false)}
            />
        </form>
    );
};

export default ShiftLogForm;
