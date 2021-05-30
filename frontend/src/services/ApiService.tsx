import Shift from "../models/Shift";
import Shifts from '../data/shifts.json';
import axios from "axios";

const _shitfs : Array<Shift> = []

const _base_api = 'https://localhost:5001/api/shift'

const fetchData = () : Promise<Shift[]> =>  {
    return new Promise<Shift[]>((resolve, reject) => {
        axios.get<Shift[]>(_base_api)
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

export { fetchData, pushData, fetchDataById }