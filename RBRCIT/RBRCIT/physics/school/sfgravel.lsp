(("CarSetup"
 Car			("Car"
			MaxSteeringLock			1.4
			FrontRollBarStiffness		10000.0
			RearRollBarStiffness		13000.0	
            )
 Drive			(":-D"
			FrontDiffMaxTorque		320.0
			CenterDiffMaxTorque		700.0
			RearDiffMaxTorque		600.0
			
			MaxBrakePressureFront	6500000
			MaxBrakePressureRear	5400000
			
			GearId0					1
			GearId1					2
			GearId2					3
			GearId3					4
			GearId4					5
			GearId5					6
			GearId6					7
			GearId7					8
			FinalDriveId				9

			DropGearId				11
				
			)
 Engine          (":-D"
			Dummy           0.000000
                 )
 VehicleControlUnit (":-D"

                CenterDiffHandbrakeRelease	0.5
				LeftFootBrakeThreshold		0.2
				
				CenterDiffThrottle_00		0.0
				CenterDiffThrottle_01		0.0625
				CenterDiffThrottle_02		0.1
				CenterDiffThrottle_03		0.25
				CenterDiffThrottle_04		0.375
				CenterDiffThrottle_05		0.5
				CenterDiffThrottle_06		0.625
				CenterDiffThrottle_07		0.75
				CenterDiffThrottle_08		1.0
				CenterDiffThrottle_09		1.0
				CenterDiffThrottle_10		1.0

				CenterDiffBrake_00			0.0
				CenterDiffBrake_01			0.1
				CenterDiffBrake_02			0.2
				CenterDiffBrake_03			0.4
				CenterDiffBrake_04			0.7
				CenterDiffBrake_05			1.0
				CenterDiffBrake_06			1.0
				CenterDiffBrake_07			1.0
				CenterDiffBrake_08			1.0
				CenterDiffBrake_09			1.0
				CenterDiffBrake_10			1.0


				CenterSpeedMapVelocity_00	00.0		CenterSpeedMapFactor_00		0.0
				CenterSpeedMapVelocity_01	05.56		CenterSpeedMapFactor_01		0.0
				CenterSpeedMapVelocity_02	11.1		CenterSpeedMapFactor_02		0.1
				CenterSpeedMapVelocity_03	16.7		CenterSpeedMapFactor_03		0.2
				CenterSpeedMapVelocity_04	22.2		CenterSpeedMapFactor_04		0.3
				CenterSpeedMapVelocity_05	27.8		CenterSpeedMapFactor_05		0.4
				CenterSpeedMapVelocity_06	33.3		CenterSpeedMapFactor_06		0.7
				CenterSpeedMapVelocity_07	38.9		CenterSpeedMapFactor_07		1.0
				CenterSpeedMapVelocity_08	44.4		CenterSpeedMapFactor_08		1.0
				CenterSpeedMapVelocity_09	50.0		CenterSpeedMapFactor_09		1.0
				CenterSpeedMapVelocity_10	55.6		CenterSpeedMapFactor_10		1.0

				LFCenterDiffThrottle_00		0.0
				LFCenterDiffThrottle_01		0.0625
				LFCenterDiffThrottle_02		0.1
				LFCenterDiffThrottle_03		0.25
				LFCenterDiffThrottle_04		0.375
				LFCenterDiffThrottle_05		0.5
				LFCenterDiffThrottle_06		0.625
				LFCenterDiffThrottle_07		0.75
				LFCenterDiffThrottle_08		1.0
				LFCenterDiffThrottle_09		1.0
				LFCenterDiffThrottle_10		1.0

				LFCenterDiffBrake_00		0.0
				LFCenterDiffBrake_01		0.0
				LFCenterDiffBrake_02		0.0
				LFCenterDiffBrake_03		0.2
				LFCenterDiffBrake_04		0.3
				LFCenterDiffBrake_05		0.5
				LFCenterDiffBrake_06		0.8
				LFCenterDiffBrake_07		1.0
				LFCenterDiffBrake_08		1.0
				LFCenterDiffBrake_09		1.0
				LFCenterDiffBrake_10		1.0


				LFCenterSpeedMapVelocity_00	00.0		LFCenterSpeedMapFactor_00		0.0
				LFCenterSpeedMapVelocity_01	05.56		LFCenterSpeedMapFactor_01		0.0
				LFCenterSpeedMapVelocity_02	11.1		LFCenterSpeedMapFactor_02		0.1
				LFCenterSpeedMapVelocity_03	16.7		LFCenterSpeedMapFactor_03		0.2
				LFCenterSpeedMapVelocity_04	22.2		LFCenterSpeedMapFactor_04		0.3
				LFCenterSpeedMapVelocity_05	27.8		LFCenterSpeedMapFactor_05		0.4
				LFCenterSpeedMapVelocity_06	33.3		LFCenterSpeedMapFactor_06		0.7
				LFCenterSpeedMapVelocity_07	38.9		LFCenterSpeedMapFactor_07		1.0
				LFCenterSpeedMapVelocity_08	44.4		LFCenterSpeedMapFactor_08		1.0
				LFCenterSpeedMapVelocity_09	50.0		LFCenterSpeedMapFactor_09		1.0
				LFCenterSpeedMapVelocity_10	55.6		LFCenterSpeedMapFactor_10		1.0	

					
				FrontDiffThrottle_00		0.0
				FrontDiffThrottle_01		0.0
				FrontDiffThrottle_02		0.167
				FrontDiffThrottle_03		0.33
				FrontDiffThrottle_04		0.5
				FrontDiffThrottle_05		0.67
				FrontDiffThrottle_06		0.833
				FrontDiffThrottle_07		1.0
				FrontDiffThrottle_08		1.0
				FrontDiffThrottle_09		1.0
				FrontDiffThrottle_10		1.0

				FrontDiffBrake_00			0.0
				FrontDiffBrake_01			0.0
				FrontDiffBrake_02			0.167
				FrontDiffBrake_03			0.33
				FrontDiffBrake_04			0.5
				FrontDiffBrake_05			0.67
				FrontDiffBrake_06			0.833
				FrontDiffBrake_07			1.0
				FrontDiffBrake_08			1.0
				FrontDiffBrake_09			1.0
				FrontDiffBrake_10			1.0


				FrontSpeedMapVelocity_00	00.0		FrontSpeedMapFactor_00		0.0
				FrontSpeedMapVelocity_01	02.78		FrontSpeedMapFactor_01		0.0
				FrontSpeedMapVelocity_02	05.56		FrontSpeedMapFactor_02		0.0
				FrontSpeedMapVelocity_03	08.33		FrontSpeedMapFactor_03		0.0
				FrontSpeedMapVelocity_04	11.1		FrontSpeedMapFactor_04		0.0
				FrontSpeedMapVelocity_05	13.8		FrontSpeedMapFactor_05		0.0
				FrontSpeedMapVelocity_06	16.7		FrontSpeedMapFactor_06		0.1
				FrontSpeedMapVelocity_07	22.2		FrontSpeedMapFactor_07		0.2
				FrontSpeedMapVelocity_08	27.7		FrontSpeedMapFactor_08		0.3
				FrontSpeedMapVelocity_09	38.9		FrontSpeedMapFactor_09		0.67
				FrontSpeedMapVelocity_10	55.6		FrontSpeedMapFactor_10		1.0


				RearDiffThrottle_00			0.0
				RearDiffThrottle_01			0.0
				RearDiffThrottle_02			0.0
				RearDiffThrottle_03			0.25
				RearDiffThrottle_04			0.50
				RearDiffThrottle_05			0.75
				RearDiffThrottle_06			1.0
				RearDiffThrottle_07			1.0
				RearDiffThrottle_08			1.0
				RearDiffThrottle_09			1.0
				RearDiffThrottle_10			1.0

				RearDiffBrake_00			0.0
				RearDiffBrake_01			0.3
				RearDiffBrake_02			0.7
				RearDiffBrake_03			1.0
				RearDiffBrake_04			1.0
				RearDiffBrake_05			1.0
				RearDiffBrake_06			1.0
				RearDiffBrake_07			1.0
				RearDiffBrake_08			1.0
				RearDiffBrake_09			1.0
				RearDiffBrake_10			1.0


				RearSpeedMapVelocity_00	00.0		RearSpeedMapFactor_00		1.0
				RearSpeedMapVelocity_01	05.56		RearSpeedMapFactor_01		1.0
				RearSpeedMapVelocity_02	11.1		RearSpeedMapFactor_02		1.0
				RearSpeedMapVelocity_03	16.7		RearSpeedMapFactor_03		1.0
				RearSpeedMapVelocity_04	22.2		RearSpeedMapFactor_04		1.0
				RearSpeedMapVelocity_05	27.8		RearSpeedMapFactor_05		0.85
				RearSpeedMapVelocity_06	33.3		RearSpeedMapFactor_06		0.70
				RearSpeedMapVelocity_07	38.9		RearSpeedMapFactor_07		0.55
				RearSpeedMapVelocity_08	44.4		RearSpeedMapFactor_08		0.40
				RearSpeedMapVelocity_09	50.0		RearSpeedMapFactor_09		0.30
				RearSpeedMapVelocity_10	55.6		RearSpeedMapFactor_10		0.2
				
               )
 WheelLF         (":-D"
		TopMountSlot			2
                SteeringRodLength		+0.34455
                StrutPlatformHeight		0.010000
                WheelAxisInclination		-0.07
                
  )

 WheelRF         (":-D"
		TopMountSlot			2
       		SteeringRodLength		+0.34455
            	StrutPlatformHeight		0.010000
            	WheelAxisInclination		-0.07
                  )

 WheelLB         (":-D"
		TopMountSlot			0
                SteeringRodLength 		+0.4504
                StrutPlatformHeight		0.030000
                WheelAxisInclination		-0.01
                  )

 WheelRB         (":-D"
		TopMountSlot			0
                SteeringRodLength 		+0.4504
                StrutPlatformHeight		0.0300000
                WheelAxisInclination		-0.01
                  )

 SpringDamperLF  (":-D"
		SpringLength    		0.31
                SpringStiffness 		50000
			
		HelperSpringMinLength		0.03
                HelperSpringLength 		0.07
                HelperSpringStiffness 		15000
                DampingBump     		5000
                DampingRebound  		5000
                BumpHighSpeedBreak 		1.5
                DampingBumpHighSpeed 		7500
                  )

 SpringDamperRF  (":-D"
		SpringLength    		0.31
		SpringStiffness 		50000

		HelperSpringMinLength		0.030
                HelperSpringLength 		0.07
		HelperSpringStiffness 		15000
		DampingBump     		5000
		DampingRebound  		5000
		BumpHighSpeedBreak 		1.5
		DampingBumpHighSpeed 		7500
                  )

 SpringDamperLB  (":-D"
		SpringLength				0.31
		SpringStiffness				45000

		HelperSpringMinLength			0.030
                HelperSpringLength 			0.07
		HelperSpringStiffness 			15000
		DampingBump     			4500
		DampingRebound  			5000
		BumpHighSpeedBreak 			1.5
		DampingBumpHighSpeed 			7500
                  )
 SpringDamperRB  (":-D"
		SpringLength    			0.31
                SpringStiffness 			45000

		HelperSpringMinLength			0.030
                HelperSpringLength 			0.07
                HelperSpringStiffness 			15000
                DampingBump     			4500
                DampingRebound  			5000
                BumpHighSpeedBreak 			1.5
                DampingBumpHighSpeed 			7500
                  )
 TyreLF          (":-D"
 		Pressure       	220000
                   )
 TyreRF          (":-D"
 		Pressure       	220000
                
                  )
 TyreLB          (":-D"
 		Pressure       	220000
                
                  )
 TyreRB          (":-D"
		Pressure       	220000
                  )
 ))