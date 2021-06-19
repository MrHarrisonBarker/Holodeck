const fs = require('fs');
const {exec} = require("child_process");

const tenants = ["", "different."];

fs.readFile(__dirname + '/src/environments/environment.prod.ts', function (err, data) {
  if (err) {
    throw err;
  }

  let env = data.toString()

  console.log(env);

  for (let i = 0; i < tenants.length; i++) {
    let prefixPos = env.search("namingPrefix");

    let firstQuote = env.indexOf('"', prefixPos) + 1;
    let nextQuote = env.indexOf('"', firstQuote) - 1;

    let firstSub = env.substring(0, firstQuote);
    let lastSub = env.substr(nextQuote + 1);

    env = firstSub + tenants[i] + lastSub;

    console.log("modified env ->", env);

    fs.writeFileSync(__dirname + '/src/environments/environment.prod.ts', env);

    exec("ng build --configuration=production", (error, stdout, stderr) => {
      if (error) {
        console.log(`error: ${error.message}`);
        return;
      }
      if (stderr) {
        console.log(`stderr: ${stderr}`);
        return;
      }
      console.log(`stdout: ${stdout}`);
    });
  }


});
