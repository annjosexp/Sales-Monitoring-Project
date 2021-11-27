import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Visit} from './visit';

@Injectable({
  providedIn: 'root'
})
export class VisitService {

  //create an instance of visit
  formData:Visit=new Visit();
  
  visits:Visit[];
  constructor(private httpClient:HttpClient) { }



//get visit
bindVisit(){
  this.httpClient.get(environment.apiUrl+"api/visit/GetAllVisit")
  .toPromise().then(response=>
    this.visits=response as Visit[])

}

//insert visit
insertVisit(visit:Visit):Observable<any>
{
  return this.httpClient.post(environment.apiUrl+"api/visit/Addvisit",visit);

}

//update visit
updateVisit(visit:Visit):Observable<any>
{
  return this.httpClient.put(environment.apiUrl+"api/visit/UpdateVisit",visit);

}


//delete employee
deleteVisit(VisitId:number):Observable<any>
{
  return this.httpClient.delete(environment.apiUrl+"api/visit/deleteVisit?id="+VisitId);

}


//get Visit by id
getEmployee(VisitId:number):Observable<any>
{
  return this.httpClient.delete(environment.apiUrl+"api/visit/GetVisitById?id="+VisitId);

}

}
