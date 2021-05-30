import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
} from "@material-ui/core";
import { ReactNode } from "react";
import Shift from "../../models/Shift";

type ShiftDialogProps = {
    open: boolean;
    title: string;
    children?: ReactNode;
    dialogActions?: ReactNode;
    onClose?: (shift: Shift) => void;
};

const ShiftDialog = (props: ShiftDialogProps) => {
    const { open, title, children, dialogActions } = props;
    return (
        <Dialog open={open}>
            <DialogTitle className="dialog-title">{title}</DialogTitle>
            <DialogContent>{children}</DialogContent>
            <DialogActions>{dialogActions}</DialogActions>
        </Dialog>
    );
};

export default ShiftDialog;
