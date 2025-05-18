import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7016/api/User'; // API URL

  constructor(private http: HttpClient) { }

  getUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // user.service.ts
addUser(user: any): Observable<any> {
  return this.http.post(`${this.apiUrl}`, user, { responseType: 'text' });
}

editUser(user: any): Observable<any> {
  return this.http.put(`${this.apiUrl}/${user.userId}`, user, { responseType: 'text' });
}

deleteUser(userId: number): Observable<any> {
  return this.http.delete(`${this.apiUrl}/${userId}`, { responseType: 'text' });
}

}
  