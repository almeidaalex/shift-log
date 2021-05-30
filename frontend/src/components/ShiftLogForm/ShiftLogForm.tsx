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
import { MouseEventHandler, useState } from "react";
import { Controller, SubmitHandler, useForm } from "react-hook-form";
import Shift from "../../models/Shift";
import { DeleteDialog } from "../DeleteDialog";
import "./AddShiftLog.css";

type ShiftFormProps = {
    onSubmit: (shift: Shift) => void;
    onDeleteConfirm?: (id: number) => void;
    data?: Shift;
};

const ShiftLogForm = (props: ShiftFormProps) => {
    const { data, onSubmit, onDeleteConfirm } = props;
    const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);
    const {
        handleSubmit,
        control,
        formState: { errors },
    } = useForm<Shift>({ defaultValues: data });

    return (
        <form className="AddShiftLog form" onSubmit={handleSubmit(onSubmit)}>
            <MuiPickersUtilsProvider utils={DateFnsUtils}>
                <Controller
                    render={({ field }) => (
                        <KeyboardDatePicker
                            disableToolbar
                            variant="inline"
                            format="dd/MM/yyyy"
                            margin="normal"
                            id="date-picker-inline"
                            label="Date picker inline"
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
                        <Select {...field} labelId="area-label">
                            <MenuItem value={1}>Control Room</MenuItem>
                            <MenuItem value={2}>Factory Floor</MenuItem>
                            <MenuItem value={3}>Expedition</MenuItem>
                        </Select>
                    </FormControl>
                )}
            />

            <Controller
                control={control}
                name="comment"
                render={({ field }) => <TextField {...field} label="Comment" />}
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
                    <TextField {...field} label="Operator" />
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
