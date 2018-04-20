import { browser, by, element } from 'protractor';

export class AppPage {
  navigateToInstituteListPage() {
    return browser.get('/institute');
  }

  navigateToInstituteAddPage() {
    return browser.get('/institute/add');
  }

  getMainHeading() {
    return element(by.css('app-root h1')).getText();
  }

  getInstituteAddPageHeading() {
    return element(by.css('app-root h1')).getText();
  }
}
