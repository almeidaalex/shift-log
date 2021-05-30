import { TableContainer, Table, TableHead, TableRow, TableCell, TableBody, Button, Typography } from "@material-ui/core";
import Shift from '../models/Shift';

interface ShiftLogProps {
    logs: Shift[];
    onEdit: (log_id: number) => void
    onDelete: (log_id: number) => void
}

export const ShiftLogList = (props: ShiftLogProps)  => {

    return (
        <>
            <Typography variant="h2">Shift Logs</Typography>
           
            <TableContainer>
                <Table >
                    <TableHead>
                        <TableRow>
                            <TableCell>Event Date</TableCell>
                            <TableCell>Area</TableCell>
                            <TableCell>Machine</TableCell>
                            <TableCell>Comment</TableCell>
                            <TableCell>Status</TableCell>     
                            <TableCell></TableCell>                            
                        </TableRow>
                    </TableHead>
                    <TableBody >
                        { props.logs.map(log => 
                            <TableRow key={log.log_id}>
                                <TableCell>{log.event_date}</TableCell>
                                <TableCell>{log.area}</TableCell>
                                <TableCell>{log.machine}</TableCell>
                                <TableCell>{log.comment}</TableCell>
                                <TableCell>{log.status}</TableCell>       
                                <TableCell>
                                    <Button onClick={_ => props.onEdit(log.log_id)}>Edit</Button>
                                    <Button onClick={_ => props.onDelete(log.log_id)}>Delete</Button>
                                </TableCell>                      
                            </TableRow>
                        )}
                    </TableBody>
                    
                </Table>
            </TableContainer>           
        </>

        
    )
};

