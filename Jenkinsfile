  pipeline{
    agent any
    
    tools {nodejs "node"}
    
    environment {
        node = 'C:\\Program Files\\nodejs\\'
        }
        
     triggers {
        githubPush()
    }
    
    stages{
        stage('Git') {
            steps {
                step([$class: 'WsCleanup'])
            }
        }
        
    stage('Checkout') {
        steps {
            git credentialsId:'57dd0dfafe04c5e3fcd7c139ca8d132b165f0d82', url:'https://github.com/HansikaW/rambase-poc/', branch:'client'\
        }    
    }
    
    stage('Restore packages') {
        steps {
            dir('client') {
               bat "npm install" 
            }
        }
     }
     
     stage('Build'){
        steps{
            dir('client') {
               bat"npm build --prod " 
            }
         }
      }
        
    stage('Unit test'){
        steps{
           dir('client') {
              bat "npm run test:ci"
           } 
        }
    }
   }
      
    post{
     always{
       emailext body: "${currentBuild.currentResult}: Job   ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
       recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
       subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
      }
    }
  }
