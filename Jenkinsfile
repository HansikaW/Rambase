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
            git credentialsId:'fbedd5086dfeab07dc2052717911a5ad3f1b5862', url:'https://github.com/HansikaW/rambase-poc/', branch:'client'\
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
               bat "npm run-script build"
              //bat"npm build --prod " 
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
      
      stage('Publish'){
         steps{ 
            dir('client\\dist') {
             
         script{
           try {
             bat 'robocopy "C:\\Program Files (x86)\\Jenkins\\workspace\\Rambase-poc_Multibranch_client\\client\\dist" *.* "D:\\publish-multibranch\\client" COPYALL /E'
          } catch (Exception e) {
           echo e.getMessage()
            echo "Error detected, but we will continue."
          }
        }
      }
      
      dir('client') {
          
        script{
           try {
             bat 'robocopy "C:\\Program Files (x86)\\Jenkins\\workspace\\Rambase-poc_Multibranch_client\\client\\src\\assets\\img" *.* "D:\\publish-multibranch\\client\\FrontEnd\\assets\\img" COPYALL /E'
          } 
          catch (Exception e) {
           echo e.getMessage()
            echo "Error detected, but we will continue."
          }
        }
      }
        
      }
     }
     
     stage('Deploy'){
        steps{
          
          script{
            try{
                bat ' "C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:IisApp=D:\\publish-multibranch\\client\\FrontEnd -dest:iisapp=rambase-multibranch-client,authType=basic,username=Hansika,password=123456 -allowUntrusted -enableRule:AppOffline'
            }
            catch (Exception e) {
                echo e.getMessage()
            }
          }
           
        }
      } 
    
    post{
     always{
       emailext body: "${currentBuild.currentResult}: Job   ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
       to: 'hansikaw@99x.lk',
       subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
      }
    }
  }
