import axios from 'axios'
 import { Message } from 'element-ui'
const service = axios.create({
  baseURL: 'http://localhost:13653/api', // api的base_url
  // baseURL: process.env.BASE_API,
  timeout: 5000 // request timeout
})

// request interceptor
service.interceptors.request.use(config => {
    // Do something before request is sent
    // config.headers['contentType'] = 'application/json'
    // if (getToken()) {
    //   config.headers['Authorization'] = ['Bearer ', getToken()].join('')
    // }
    return config
  }, error => {
    // Do something with request error
    // console.log(error) // for debug
    Promise.reject(error)
  })
  
  // respone interceptor
  service.interceptors.response.use(
    response => response,
    error => {
      const data = error.response.data
      const errorMsg = data.errorCode
      switch (data.errorType) {
        case 0:
          Message({
            message: errorMsg,
            type: 'error',
            duration: 5 * 1000
          })
          break
        case 1:
        default:
          break;
      }
      return Promise.reject(errorMsg)
    })
  
  export default service
  