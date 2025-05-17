import { EventEmitter, Events } from "@/providers/event-emitter";
import { DepartmentsService } from "@/services/almox/departments.service";
import type { DepartmentSummary } from "@/types/entities/departments.types";
import { Button, Table, Text } from "@mantine/core";
import { IconArrowRight } from "@tabler/icons-react";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router";
import dayjs from "dayjs"

export function DepartmentsTable() {
    
    const [departments, setDepartments] = useState<DepartmentSummary[]>([]);
    const [_, setSearchParams] = useSearchParams();
        
    const updateDepartments = async () => {
        const response = await DepartmentsService.get();
        setDepartments(response);
    }

    useEffect(() => { updateDepartments() }, [])
    useEffect(() => EventEmitter.subscribe(Events.REFRESH, updateDepartments), [])

    return (
        <Table>
            <Table.Thead>
                <Table.Tr>
                    <Table.Th>#</Table.Th>
                    <Table.Th>Department</Table.Th>
                    <Table.Th>Creation Date</Table.Th>
                    <Table.Th>Status</Table.Th>
                    <Table.Th>Details</Table.Th>
                </Table.Tr>
            </Table.Thead>

            <Table.Tbody>
                {departments.map((department, i) => (
                    <Table.Tr 
                        key={department.id} 
                        onClick={() => setSearchParams({ departmentId: department.id })}
                    >
                        <Table.Td>{ i + 1 }</Table.Td>
                        <Table.Td>{ department.name }</Table.Td>
                        <Table.Td>
                            { dayjs(department.createdAt).format("DD/MM/YYYY") }
                        </Table.Td>
                        <Table.Td>
                            <Text
                                w="max-content" p="0.5rem 1rem" c="white" 
                                bg={department.deletedAt ? "red" :"green"}
                                style={{ borderRadius: 10 }}
                            >
                                { department.deletedAt ? "Deleted" :"Active" }
                            </Text>
                        </Table.Td>
                        <Table.Td>
                            <Button
                                rightSection={<IconArrowRight/>} 
                                variant="white" p={0} 
                            />
                        </Table.Td>
                    </Table.Tr>
                ))}
            </Table.Tbody>
        </Table>
    )
}