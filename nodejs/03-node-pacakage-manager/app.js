/***
 * To install module: node install module-name. Ex:
 *
 *      > npm install underscore
 *
 * Ideally, the modules or 3rd party libraries should not be committed
 * along the code to repository, such as GitHub. Instead, only the modules'
 * names are stored into package.json. So when other developers checkout
 * or clone the code, they would just simply re-install all the required
 * modules into their local working directory.
 *
 * To persist the modules' names to package.json, run the following command:
 *
 *      > npm install underscore --save
 *
 * NOTE: package.json file cannot be empty, at least it has to have some
 *       entries, for e.g.:
 *
 *       {
              "name": "03-node-package-manager",
              "version": "0.0.0",
              "description": "Learn how to use npm (node package manager)",
              "main": "app.js"
         }
 *
 * To re-install required modules from package.json, run following command:
 *
 *      > npm install
 *
 * To un-install, simply run following command:
 *
 *      > npm uninstall underscore
 *
 **/

/***
 * With modules installed from npm, we do not have to specify the actual
 * path of where the modules' folder located. We can simply specify
 * modules' names only.
 **/
var _ = require('underscore');
