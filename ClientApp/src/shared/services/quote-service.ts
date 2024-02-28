import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseModel } from '../models/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {
  private apiUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
   }

  getRandomQuote(): Observable<any> {
    return this.http.get<ResponseModel<Quote>>((this.apiUrl + 'Quotes/get-random-quote'));
  }
  getQuotesByAuthorAndLength(author: string, count: number): Observable<any>{
    return this.http.get<ResponseModel<QuotesList>>((this.apiUrl + 'Quotes/get-quotes-list'), {params: {authorName: author, count: count}});
  }
}

export interface Quote {
    content: string;
    author: string;
    length: number;
}

export interface QuotesList {
    shortLengthQuotes : Quote[];
    mediumLengthQuotes : Quote[];
    longLengthQuotes : Quote[];
}