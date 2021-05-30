import { 
    Dialog, 
    DialogContent, 
    DialogTitle } 
    from "@material-ui/core"
import { ReactNode } from "react"
import Shift from "../../models/Shift"

type ShiftDialogProps = {
    open: boolean,
    title: string,
    children?: ReactNode,    
    onClose?: (shift: Shift) => void;
}

const ShiftDialog = (props: ShiftDialogProps) => {
    const {open, title, children} = props
    return (
        <Dialog open={open} >
            <DialogTitle className="dialog-title">
                {title}               
            </DialogTitle>
            <DialogContent>
                {children}    
            </DialogContent>
        </Dialog>
    )
}

export default ShiftDialog