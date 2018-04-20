import { AppPage } from './app.po';

describe('App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('Institutes list page should have Institutes heading', () => {
    page.navigateToInstituteListPage();
    expect(page.getMainHeading()).toEqual('Institutes');
  });

  it('Institute add page should have currect heading', () => {
    page.navigateToInstituteAddPage();
    expect(page.getInstituteAddPageHeading()).toEqual("Add new Institute");
  });

});
