import Shift from "../models/Shift";
import axios from "axios";
import ShiftView from "../models/ShiftView";

const _base_api = process.env.BASE_URL || "https://localhost:5001/api/shift"

const fetchData = () : Promise<ShiftView[]> =>  {
    return new Promise<ShiftView[]>((resolve, reject) => {
        axios.get<ShiftView[]>(_base_api)
        .then(resp => resolve(resp.data))
        .catch(err => reject(err))
    })
}

const fetchDataById = (id: number) =>  {
    return new Promise<Shift>((resolve, reject) => {
        axios.get<Shift>(`${_base_api}/${id}`)
        .then(resp => resolve(resp.data))
        .catch(err => reject(err))
    })
}

const pushData = (data: Shift) => {
    return new Promise((resolve, reject) => {
        axios.post(_base_api, data)
        .then(resp => resolve(resp.data))
        .catch(err => reject(err))
    })
}

const editData = (id: number, data: Shift) => {
    return new Promise((resolve, reject) => {
        axios.put(`${_base_api}/${id}`, data)
        .then(resp => resolve(resp.data))
        .catch(err => reject(err))
    })
}

const deleteData = (id: number) => {
    return new Promise((resolve, reject) => {
        axios.delete(`${_base_api}/${id}`)
        .then(resp => resolve(resp.data))
        .catch(err => reject(err))
    })
}

export { fetchData, pushData, fetchDataById, editData, deleteData }