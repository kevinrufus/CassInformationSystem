import { Component, OnInit } from '@angular/core';
import { faQuoteLeft } from '@fortawesome/free-solid-svg-icons';
import { Quote, QuoteService, QuotesList } from 'src/shared/services/quote-service';
import { ResponseModel } from 'src/shared/models/ResponseModel';

@Component({
  selector: 'app-welcome-page',
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css']
})
export class WelcomePageComponent implements OnInit {
  public quote: Quote = { author: '', content: '', length: 0 };
  public quotesList: QuotesList = {shortLengthQuotes: [], mediumLengthQuotes: [], longLengthQuotes: []};
  faQuote = faQuoteLeft;
  currentTab: 'short' | 'medium' | 'long' = 'short';
  constructor(private quoteService: QuoteService) { }

  ngOnInit(): void {
    this.quoteService.getRandomQuote().subscribe((response: ResponseModel<Quote>) => {
      this.quote = response.data; 
    });
    this.quoteService.getQuotesByAuthorAndLength("Albert Einstein", 30).subscribe((response: ResponseModel<QuotesList>) => {
      this.quotesList.shortLengthQuotes = response.data.shortLengthQuotes;
      this.quotesList.mediumLengthQuotes = response.data.mediumLengthQuotes;
      this.quotesList.longLengthQuotes = response.data.longLengthQuotes;
    });
  }

  changeTab(tab: 'short' | 'medium' | 'long'): void {
    this.currentTab = tab;
  }
}
