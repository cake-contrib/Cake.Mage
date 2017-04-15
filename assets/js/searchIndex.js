
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"TrustLevel",
        content:"TrustLevel",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"BaseNewAndUpdateMageSettings",
        content:"BaseNewAndUpdateMageSettings",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"BaseNewAndUpdateApplicationSettings",
        content:"BaseNewAndUpdateApplicationSettings",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"NewApplicationSettings",
        content:"NewApplicationSettings",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"NewDeploymentSettings",
        content:"NewDeploymentSettings",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"BaseNewAndUpdateDeploymentSettings",
        content:"BaseNewAndUpdateDeploymentSettings",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"Processor",
        content:"Processor",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"MageAliases",
        content:"MageAliases",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"SignSettings",
        content:"SignSettings",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"UpdateDeploymentSettings",
        content:"UpdateDeploymentSettings",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"UpdateApplicationSettings",
        content:"UpdateApplicationSettings",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"Algorithm",
        content:"Algorithm",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/TrustLevel',
        title:"TrustLevel",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/BaseNewAndUpdateMageSettings',
        title:"BaseNewAndUpdateMageSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/BaseNewAndUpdateApplicationSettings',
        title:"BaseNewAndUpdateApplicationSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/NewApplicationSettings',
        title:"NewApplicationSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/NewDeploymentSettings',
        title:"NewDeploymentSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/BaseNewAndUpdateDeploymentSettings',
        title:"BaseNewAndUpdateDeploymentSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/Processor',
        title:"Processor",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/MageAliases',
        title:"MageAliases",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/SignSettings',
        title:"SignSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/UpdateDeploymentSettings',
        title:"UpdateDeploymentSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/UpdateApplicationSettings',
        title:"UpdateApplicationSettings",
        description:""
    });

    y({
        url:'/Cake.Mage/Cake.Mage/api/Cake.Mage/Algorithm',
        title:"Algorithm",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
