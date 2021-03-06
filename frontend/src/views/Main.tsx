import { Button } from "@material-ui/core";
import { useEffect, useState } from "react";
import ShiftDialog from "../components/ShiftDialog/ShiftDialog";
import Shift from "../models/Shift";
import {
    deleteData,
    editData,
    fetchData,
    fetchDataById,
    pushData,
} from "../services/ApiService";
import ShiftLogForm from "../components/ShiftLogForm/ShiftLogForm";
import { ShiftLogList } from "../components/ShiftLogList";
import ShiftView from "../models/ShiftView";

const Main = () => {
    const [openAdd, setOpenAdd] = useState(false);
    const [openEdit, setOpenEdit] = useState(false);
    const [logs, setShiftLogs] = useState<ShiftView[]>([]);
    const [shift, setShift] = useState<Shift>();

    useEffect(() => {
        const fetch = async () => setShiftLogs(await fetchData());
        fetch();
    }, []);

    const onSuccessfulOperation = async () => {
        setShiftLogs(await fetchData());     
    };

    const onAddShift = (shift: Shift): void => {
        console.debug(shift);
        pushData(shift)
            .then(() => {
                setOpenAdd(false);
            })
            .then(onSuccessfulOperation)
            .catch((er) => console.debug(er));
    };

    const onEditingShift = (log_id: number): void => {
        fetchDataById(log_id).then((shift) => {
            setShift(shift);
            setOpenEdit(true);
        });
    };

    const onDeletingShift = (log_id: number): void => {
        deleteData(log_id).then(() => {
            setOpenEdit(false)
            console.log(`Deleted ${log_id}`);
        })
        .then(onSuccessfulOperation);
    };

    const onEditShift = (shift: Shift): void => {
        editData(1, shift)
            .then(() => setOpenEdit(false))
            .then(onSuccessfulOperation);
    };

    return (
        <>
            <Button
                variant="contained"
                color="primary"
                onClick={() => setOpenAdd(true)}
            >
                Add Shift Log
            </Button>

            <ShiftDialog title="Add Shift Log" open={openAdd} onClose={() => setOpenAdd(false)}>
                <ShiftLogForm onSubmit={onAddShift} ></ShiftLogForm>
            </ShiftDialog>

            <ShiftDialog title="Edit Shift Log" open={openEdit} onClose={() => setOpenEdit(false)}>
                <ShiftLogForm
                    onSubmit={onEditShift}
                    data={shift}
                    onDeleteConfirm={onDeletingShift}                    
                ></ShiftLogForm>
            </ShiftDialog>

            <ShiftLogList
                logs={logs}
                onEdit={onEditingShift}
                onDelete={onDeletingShift}
            />
        </>
    );
};

export default Main;
