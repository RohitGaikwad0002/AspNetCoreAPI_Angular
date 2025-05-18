import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleRightsService {
  private apiUrl = 'https://localhost:7016/api/RoleRight'; // API URL

  constructor(private http: HttpClient) { }

  getAllRoleRights(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  updateRoleRights(rolerights: any): Observable<any> {
    console.log(rolerights);
    return this.http.put(`${this.apiUrl}`, rolerights, { responseType: 'text' });
  }
}
