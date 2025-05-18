import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private apiUrl = 'https://localhost:7016/api/Role'; // API URL

  constructor(private http: HttpClient) { }

  getRoles(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

    // role.service.ts
addRole(role: any): Observable<any> {
  return this.http.post(`${this.apiUrl}`, role, { responseType: 'text' });
}

editRole(role: any): Observable<any> {
  return this.http.put(`${this.apiUrl}/${role.roleId}`, role, { responseType: 'text' });
}

deleteRole(roleId: number): Observable<any> {
  return this.http.delete(`${this.apiUrl}/${roleId}`, { responseType: 'text' });
}
}
  