import config from '../Config'
import axios from 'axios'

export default class PostService
{
    constructor() {
        this.posts = axios.create({
            baseURL: config.baseUrl,
            timeout: 60000
          })
    }

    async GetAllPosts() {
        const path = `${config.urls.GetPosts}?page=1&qtd=10`
        const response = await this.posts.get(path) 
        return response.data       
    }

    async GetPost(idOrPath){
        const path = `${config.urls.GetPost}?id=${idOrPath}/`
        const response = await this.posts.get(path) 
        return response.data     
    }

}