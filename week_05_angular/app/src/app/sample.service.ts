export class MyDataService {
  names: Array<any>

  constructor () {
    this.names = ['John', 'Mary', 'Joan']
  }

  getNames () {
    return this.names
  }

  getDon () {
    return 'Don'
  }
}
