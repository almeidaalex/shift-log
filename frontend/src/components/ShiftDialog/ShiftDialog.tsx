import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
} from "@material-ui/core";
import { ReactNode } from "react";

type ShiftDialogProps = {
    open: boolean;
    title: string;
    children?: ReactNode;
    dialogActions?: ReactNode;
    onClose?: () => void;
};

const ShiftDialog = (props: ShiftDialogProps) => {
    const { open, title, children, dialogActions, onClose } = props;
    
    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle className="dialog-title">{title}</DialogTitle>
            <DialogContent>{children}</DialogContent>
            <DialogActions>{dialogActions}</DialogActions>
        </Dialog>
    );
};

export default ShiftDialog;
