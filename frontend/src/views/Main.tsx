import { Button } from "@material-ui/core";
import { useEffect, useState } from "react";
import ShiftDialog from "../components/ShiftDialog/ShiftDialog";
import Shift from "../models/Shift";
import { fetchData, fetchDataById, pushData } from '../services/ApiService';
import ShiftLogForm from '../components/ShiftLogForm/ShiftLogForm'
import { ShiftLogList } from "../components/ShiftLogList";

const Main = () => {

    const [openAdd, setOpenAdd] = useState(false)
    const [openEdit, setOpenEdit] = useState(false)
    const [logs, setShiftLogs] = useState<Shift[]>([])
    const [shift, setShift] = useState<Shift>()

    useEffect(() => {
        const fetch = async () => setShiftLogs(await fetchData())        
        fetch()
    }, [])

    const onAddShift = (shift: Shift) : void => {                
        pushData(shift).then(() => {
            setOpenAdd(false)
        })
        .catch(er => console.log(er))       
    }

    const onEditingShift = (log_id: number) : void => {  
        fetchDataById(log_id).then( shift => {
            setShift(shift)
            setOpenEdit(true)                       
            console.log(`Editing ${shift}`)
        });
        console.log(`Editing ${log_id}`)
    }

    const onDeletingShift = (log_id: number) : void => {        
        console.log(`Deleting ${log_id}`)
    }

    const onEditShift = (shift: Shift) : void => {
        pushData(shift).then(() => setOpenEdit(false))
    }

    return (
        <>
            <Button variant="contained" color="primary" onClick={() => setOpenAdd(true)}>
                Add Shift Log           
            </Button>

            <ShiftDialog title="Add Shift Log" open={openAdd}>
                <ShiftLogForm onSubmit={onAddShift} ></ShiftLogForm>                
            </ShiftDialog>

            <ShiftDialog title="Edit Shift Log" open={openEdit}>
                <ShiftLogForm onSubmit={onEditShift} data={shift} ></ShiftLogForm>
            </ShiftDialog>

            <ShiftLogList logs={logs} onEdit={onEditingShift} onDelete={onDeletingShift} />
        </>
    )
}

export default Main
