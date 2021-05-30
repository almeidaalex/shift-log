import { Button, Typography } from "@material-ui/core";
import React from "react";
import ShiftDialog from "./ShiftDialog/ShiftDialog";

type DeleteDialogProps = {
    open: boolean;
    onConfirm: () => void;
    onCancel?: () => void;
};

export const DeleteDialog = (props: DeleteDialogProps) => {
    const { open, onConfirm, onCancel } = props;
    return (
        <ShiftDialog
            title="Do you want to delete?"
            open={open}
            dialogActions={
                <>
                    <Button name="confirm" color="secondary" variant="outlined" onClick={onConfirm}>
                        Confirm
                    </Button>
                    <Button name="cancel" variant="outlined" onClick={onCancel}>
                        Cancel
                    </Button>
                </>
            }
        ></ShiftDialog>
    );
};
