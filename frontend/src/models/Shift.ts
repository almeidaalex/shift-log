interface Shift {
    log_id: number,
    status: boolean,
    eventDate: Date,
    area: number,    
    machine: string,
    operator: string,
    comment: string
}

export default Shift
