import request from '@/utils/request'

export function search(name) {
  return request({
    url: '/values/' + name ,
    method: 'get'
  })
}

export function edit(name) {
    return request({
      url: '/values/' + name,
      method: 'put'
    })
  }