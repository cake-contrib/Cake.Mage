
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"UpdateApplicationSettings",
            content:"UpdateApplicationSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/UpdateApplicationSettings',
            title:"UpdateApplicationSettings",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"MageAliases",
            content:"MageAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/MageAliases',
            title:"MageAliases",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"NewDeploymentSettings",
            content:"NewDeploymentSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/NewDeploymentSettings',
            title:"NewDeploymentSettings",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"BaseNewAndUpdateDeploymentSettings",
            content:"BaseNewAndUpdateDeploymentSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/BaseNewAndUpdateDeploymentSettings',
            title:"BaseNewAndUpdateDeploymentSettings",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"BaseNewAndUpdateMageSettings",
            content:"BaseNewAndUpdateMageSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/BaseNewAndUpdateMageSettings',
            title:"BaseNewAndUpdateMageSettings",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"SignSettings",
            content:"SignSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/SignSettings',
            title:"SignSettings",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"Algorithm",
            content:"Algorithm",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/Algorithm',
            title:"Algorithm",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"Processor",
            content:"Processor",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/Processor',
            title:"Processor",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"UpdateDeploymentSettings",
            content:"UpdateDeploymentSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/UpdateDeploymentSettings',
            title:"UpdateDeploymentSettings",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"BaseNewAndUpdateApplicationSettings",
            content:"BaseNewAndUpdateApplicationSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/BaseNewAndUpdateApplicationSettings',
            title:"BaseNewAndUpdateApplicationSettings",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"TrustLevel",
            content:"TrustLevel",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/TrustLevel',
            title:"TrustLevel",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"NewApplicationSettings",
            content:"NewApplicationSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Mage/api/Cake.Mage/NewApplicationSettings',
            title:"NewApplicationSettings",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
