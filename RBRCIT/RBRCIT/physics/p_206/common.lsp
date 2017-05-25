(("PhysicsEngine" 
  DefManager (		 
			("Car" ("CAR_ROOT"
					  
					  
						
						
					  DangerousAcceleration	  	1000000.0

					Engine	("Engine"
							Turbo 1
							
							VE00	0.5
							VE01	0.6
							VE02	0.87
							VE03	0.93
							VE04	0.98
							VE05	1.00
							VE06	1.00
							VE07	1.00
							VE08	0.993
							VE09	0.985
							VE10	0.98
							VE11	0.95
							VE12	0.90
							VE13	0.80
							VE14	0.50
							VE15	0.30
						)

						
					  Drive           ("Drive"
									   )

					  LightSystem	("LightSystem"
				
							BrakeLight0		1
							BrakeLight1		1
							BrakeLight2		1

							LowBeam0		1
							LowBeam1		1

							HighBeam0		1
							HighBeam1		1

							ReverseLight0		1
							ReverseLight1		1

							RearLight0		1
							RearLight1		1
									
								)
					
					  
					  ControlUnit	("ControlUnit"
									   Gear0Upshift		0.0
									   Gear0Downshift	0.0
									   Gear1Upshift		0.0
									   Gear1Downshift	0.0
									   Gear2Upshift		6200.0
									   Gear2Downshift	0.0
									   Gear3Upshift		6200.0
									   Gear3Downshift  	3000.0
									   Gear4Upshift		6200.0
									   Gear4Downshift	3200.0
									   Gear5Upshift		6200.0
									   Gear5Downshift	3400.0
									   Gear6Upshift		6200.0
									   Gear6Downshift	3400.0
									   Gear7Upshift		0.0
									   Gear7Downshift	3800.0
							)
						
					  iCollisionMesh	1
					  ))
			
				("HingedBody" ("CAR_DOOR_L"

							vecHingeAxis_RF 	 0.0  0.0  1.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 0.796 -2.066  0.537

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0 -0.5  0.0

							vecFaceNormal_BF	 0.0  0.0  -1.0

							HingeMinAngle		 -2.1
							HingeMaxAngle		 0.01
							HingeDefaultAngle	 0.01

							InverseMass		 0.05
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							InertiaHingeAxis	 5.0	

							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							FaceArea		1.0
							
							Spring0Type		2
							Spring0Pos		-0.75	
							Spring0Stiff		5000.0
							Spring0Damp		100.0
							Spring0MaxDisp		0.05
							Spring0Span		0.73
					
							BodyId 0

						 ))

				("HingedBody" ("CAR_DOOR_R"

							vecHingeAxis_RF 	 0.0  0.0  -1.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 -0.796 -2.066  0.537

							vecHingeAxis_BF 	 0.0  0.0  1.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0 -0.5  0.0

							vecFaceNormal_BF	 0.0  0.0  -1.0

							HingeMinAngle		 -2.1
							HingeMaxAngle		 0.01
							HingeDefaultAngle	 0.01

							InverseMass		 0.05
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							
							InertiaHingeAxis	 5.0	

							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							FaceArea		1.0
							
							Spring0Type		2
							Spring0Pos		-0.75	
							Spring0Stiff		5000.0
							Spring0Damp		100.0
							Spring0MaxDisp		0.05
							Spring0Span		0.73

							BodyId	1

						 ))

				("HingedBody" ("CAR_BONNET"

							vecHingeAxis_RF 	 1.0  0.0  0.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 0.703 -2.085  0.807

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.35  0.3  0.0

							vecFaceNormal_BF	 0.0  -0.45  -0.83939

							HingeMinAngle		 -1.7
							HingeMaxAngle		 -0.0
							HingeDefaultAngle	 -0.0

							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							InertiaHingeAxis	 1.5

							FaceArea		2.0

							Spring0Type		2
							Spring0Pos		-1.05	
							Spring0Stiff		2000.0
							Spring0Damp		20.0
							Spring0MaxDisp		0.07
							Spring0Span		1.00

							Sleepable		 1	
					  		SleepDelay		 2.0
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 1.0	

							BodyId			2

						 ))

				("HingedBody" ("CAR_EXHAUSTPIPE"

							vecHingeAxis_RF 	 1.0  0.0  0.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 -0.206  0.223  0.166

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0  -0.3  0.0

							HingeMinAngle		 -0.8
							HingeMaxAngle		 +0.2
							HingeDefaultAngle	 +0.1

							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							InertiaHingeAxis	 1.5	

							Spring0Type		2
							Spring0Pos		0.05	
							Spring0Stiff		9000.0
							Spring0Damp		150.0
							Spring0MaxDisp		0.5
							Spring0Span		0.03

							Sleepable		 1	
					  		SleepDelay		 2.0
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 1.0	

								
							Unlocked		 1

							BreakChain		 1	

							BodyId			3	

						 ))
			
				("MountedBody" ("CAR_BUMPER_F"

							vecBasePoint_PRF	0.0 -3.038 0.205
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			0

	

						 ))


				("MountedBody" ("CAR_BUMPER_B"

							vecBasePoint_PRF	0.0 0.441 0.276
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			1

	

						 ))


				("MountedBody" ("CAR_WING"

							vecBasePoint_PRF	0.0 0.371 1.017
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			2
	

						 ))


)))
