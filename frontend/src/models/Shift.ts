interface Shift {
    log_id: number,
    status: boolean,
    event_date: Date,
    area: number,    
    machine: string,
    operator: string,
    comment: string
}

export default Shift
