import { Injectable } from '@angular/core';
import { Tag } from '../../models/tag/Tag';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class TagService {

  constructor(private http: HttpClient) {}

  getAll(){ 
    return this.http.get<Tag[]>('api/tag');
  }
}
