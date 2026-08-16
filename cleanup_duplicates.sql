DELETE FROM test_plan_criteria
WHERE ctid NOT IN (
    SELECT MIN(ctid)
    FROM test_plan_criteria
    GROUP BY "TestPlanId", "CriteriaType", "Description"
);
