import axios from "axios";
import { UrlBackEnd } from "./Constants/oidc-config";

//const endpoint = "https://jsonplaceholder.typicode.com";
const endpoint = UrlBackEnd;
const token = localStorage.getItem("token");

export function get(url) {
  console.log(token);
  return axios.get(endpoint + url);
}

export function put(url, body) {
  return axios.put(endpoint + url,{
    headers: { Authorization: `Bearer ${token}` },
    body
  });
}

export function post(url, body) {
  return axios.post(endpoint + url, {
    headers: { Authorization: `Bearer ${token}` },
    body
  });
}

export function del(url) {
  return axios.delete(endpoint + url, {
    headers: { Authorization: `Bearer ${token}` },
  });
}
