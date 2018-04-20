import { browser, by, element } from 'protractor';

export class AppPage {
  navigateToInstituteListPage() {
    return browser.get('/institute');
  }

  getMainHeading() {
    return element(by.css('app-root h1')).getText();
  }
}
