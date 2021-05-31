import {
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button,
  Typography,
  Switch,
} from "@material-ui/core";
import ShiftView from "../models/ShiftView";

interface ShiftLogProps {
  logs: ShiftView[];
  onEdit: (log_id: number) => void;
  onDelete: (log_id: number) => void;
}

export const ShiftLogList = (props: ShiftLogProps) => {
  return (
    <>
      <Typography variant="h4">Shift Logs</Typography>

      <TableContainer>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Event Date</TableCell>
              <TableCell>Area</TableCell>
              <TableCell>Machine</TableCell>
              <TableCell>Comment</TableCell>
              <TableCell>Operator</TableCell>
              <TableCell>Status</TableCell>              
              <TableCell></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {props.logs.map((log) => (
              <TableRow key={log.id}>
                <TableCell>
                  {new Intl.DateTimeFormat("en-US", {
                    year: "numeric",
                    month: "numeric",
                    day: "2-digit",
                  }).format(new Date(log.eventDate))}
                </TableCell>
                <TableCell>{log.area}</TableCell>
                <TableCell>{log.machine}</TableCell>
                <TableCell>{log.comment}</TableCell>                
                <TableCell>{log.operator}</TableCell>
                <TableCell>
                  <Switch checked={log.status} />
                </TableCell>
                <TableCell>
                  <Button color="primary" variant="outlined" onClick={() => props.onEdit(log.id)} id="btn-edit">
                    Edit
                  </Button>                  
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
};
